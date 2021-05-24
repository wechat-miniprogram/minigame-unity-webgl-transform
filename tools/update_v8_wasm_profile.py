# -*- coding: utf-8 -*-

import sys
import re
import os


def main(cpuprofile_file, symbol_file):
    print('start parse symbol')
    symbol_map = {}
    with open(symbol_file) as f:
        symbol_text = f.read()
        result = re.findall(r"(\d+):'(.*)'", symbol_text)
        for p in result:
            symbol_map['wasm-function['+str(p[0])+']'] = p[1]

    parts = os.path.splitext(cpuprofile_file)
    out_file = parts[0] + '_out' + parts[1]
    total = len(symbol_map)
    print('start replace, symbol count {0}'.format(total))
    count = 0
    all_md5s = []
    with open(cpuprofile_file) as f:
        profile_text = f.read()
        for k, v in symbol_map.iteritems():
            count += 1
            strip_name = []
            for p in v.split('_'):
                if len(p) != 41:
                    strip_name.append(p)
                else:
                    all_md5s.append(p)
            profile_text = profile_text.replace(k, '_'.join(strip_name))
            if count % 1000 == 0:
                print('symbol {0}/{1}'.format(count, total))
    print('remove md5 count {0}'.format(len(all_md5s)))
    count = 0
    for m in all_md5s:
        count += 1
        profile_text = profile_text.replace(m, '')
        if count % 1000 == 0:
            print('md5 {0}/{1}'.format(count, total))

    with open(out_file, 'w') as f:
        f.write(profile_text)
    print('done')






if __name__ == '__main__':
    if len(sys.argv) != 3:
        print('usage: python update_v8_wasm_profile.py xxx.cpuprofile xxx.symbols')
    else:
        main(sys.argv[1], sys.argv[2])