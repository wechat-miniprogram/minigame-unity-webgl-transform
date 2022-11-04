using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HashGenerator : ScriptingTest {

	public TextMesh output;

	// constants [§4.2.2]
	uint[] K = new uint[] {
		0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
		0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
		0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
		0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
		0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
		0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
		0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
		0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2 };
	// initial hash value [§5.3.1]
	uint[] H = new uint[] {
		0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a, 0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19 };

	uint ROTR (int n, uint x) {
		return (x >> n) | (x << (32-n));
	}

	/**
	 * Logical functions [§4.1.2].
	 * @private
	 */
	uint E0(uint x) { return ROTR(2,  x) ^ ROTR(13, x) ^ ROTR(22, x); }
	uint E1(uint x) { return ROTR(6,  x) ^ ROTR(11, x) ^ ROTR(25, x); }
	uint D0(uint x) { return ROTR(7,  x) ^ ROTR(18, x) ^ (x>>3);  }
	uint D1(uint x) { return ROTR(17, x) ^ ROTR(19, x) ^ (x>>10); }
	uint Ch (uint x, uint y, uint z) { return (x & y) ^ (~x & z); }
	uint Maj(uint x, uint y, uint z) { return (x & y) ^ (x & z) ^ (y & z); }

	// Use this for initialization
	string SHA256 (string msg) 
	{
		// PREPROCESSING 
	 
		msg += (char)0x80;  // add trailing '1' bit (+ 0's padding) to string [§5.1.1]

		// convert string msg into 512-bit/16-integer blocks arrays of ints [§5.2.1]
		var l = (uint)msg.Length/4 + 2; // length (in 32-bit integers) of msg + ‘1’ + appended length
		var N = (uint)Mathf.Ceil(l/16);  // number of 16-integer-blocks required to hold 'l' ints
		var M = new uint[N,16];

		for (var i=0; i<N; i++) {
			for (var j=0; j<16; j++) {  // encode 4 chars per integer, big-endian encoding
				M[i,j] = (((uint)msg[i*64+j*4])<<24) | (((uint)msg[i*64+j*4+1])<<16) | 
						  (((uint)msg[i*64+j*4+2])<<8) | ((uint)msg[i*64+j*4+3]);
			} // note running off the end of msg is ok 'cos bitwise ops on NaN return 0
		}
		// add length (in bits) into final pair of 32-bit integers (big-endian) [§5.1.1]
		// note: most significant word would be (len-1)*8 >>> 32, but since JS converts
		// bitwise-op args to 32 bits, we need to simulate this by arithmetic operators
		M[N-1,14] = 0; 
		M[N-1,15] = ((l-1)*8);


		// HASH COMPUTATION [§6.1.2]

		var W = new uint[64]; 
		uint a, b, c, d, e, f, g, h;
		for (var i=0; i<N; i++) {

			// 1 - prepare message schedule 'W'
			for (var t=0;  t<16; t++) W[t] = M[i,t];
			for (var t=16; t<64; t++) W[t] = (D1(W[t-2]) + W[t-7] + D0(W[t-15]) + W[t-16]) & 0xffffffff;

			// 2 - initialise working variables a, b, c, d, e, f, g, h with previous hash value
			a = H[0]; b = H[1]; c = H[2]; d = H[3]; e = H[4]; f = H[5]; g = H[6]; h = H[7];

			// 3 - main loop (note 'addition modulo 2^32')
			for (var t=0; t<64; t++) {
				var T1 = h + E1(e) + Ch(e, f, g) + K[t] + W[t];
				var T2 =     E0(a) + Maj(a, b, c);
				h = g;
				g = f;
				f = e;
				e = (d + T1) & 0xffffffff;
				d = c;
				c = b;
				b = a;
				a = (T1 + T2) & 0xffffffff;
			}
			 // 4 - compute the new intermediate hash value (note 'addition modulo 2^32')
			H[0] = (H[0]+a) & 0xffffffff;
			H[1] = (H[1]+b) & 0xffffffff; 
			H[2] = (H[2]+c) & 0xffffffff; 
			H[3] = (H[3]+d) & 0xffffffff; 
			H[4] = (H[4]+e) & 0xffffffff;
			H[5] = (H[5]+f) & 0xffffffff;
			H[6] = (H[6]+g) & 0xffffffff; 
			H[7] = (H[7]+h) & 0xffffffff; 
		}

		var ret = "";
		foreach (var hh in H)
			ret += hh.ToString("X8");

		return ret;
	}	

	// Update is called once per frame
	uint count = 0;
	string sha = "";
	public override void UpdateTest () 
	{
		var str = count++.ToString("X8");
		str = str+str+str+str;
		str = str+str+str+str;
		var res = SHA256(str);
		sha += res + "\n";
/*
		var increment = 1 + (int)((curFPS - goalFPS) / 10);
		if (increment > 0)
			score += increment;
		var sha = "";
		for (int i=0; i<score; i++)
		{
			var str = count++.ToString("X8");
			str = str+str+str+str;
			str = str+str+str+str;
			var res = SHA256(str);
			if (i < 100)
				sha += res + "\n";
		}
		output.text = sha;*/
	}

		public override void UpdateFrame ()
		{
			if (sha.Length > 2000)
				sha = sha.Substring (sha.Length-2000);
			output.text = sha;
		}

}
