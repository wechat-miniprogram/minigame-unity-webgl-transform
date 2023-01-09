var AdmZip = require("adm-zip");
var fs = require("fs");
var Path = require("path");

if (process.argv.length < 4) {
    console.error("need source path");
    process.exit(-1);
}

var sourcePath = process.argv[2];
var distPath = process.argv[3];

var zip = new AdmZip();
zip.addLocalFile(sourcePath)
zip.writeZip(distPath)
