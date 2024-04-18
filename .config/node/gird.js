const fs = require("fs");
const path = require("path");
const root = process.cwd();
const vpPath = path.resolve(
  root,
  "./node_modules/vitepress/dist/client/theme-default/components/VPFeatures.vue"
);
if (fs.existsSync(vpPath)) {
  let content = fs.readFileSync(vpPath, { encoding: "utf-8" });
  content = content.replace(`return 'grid-4'`, `return 'grid-6'`);
  fs.rmSync(vpPath);
  fs.writeFileSync(vpPath, content, { encoding: "utf-8" });
}
