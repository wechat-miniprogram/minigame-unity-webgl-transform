import moduleHelper from "./module-helper";
const gameClubs = {};
const msg = 'GameClubButton不存在';
function printErrMsg(id) {
  console.error(msg, id);
}
const typeEnum = {
  0: 'text',
  1: 'image',
}
const iconEnum = {
  0: 'green',
  1: 'white',
  2: 'dark',
  3: 'light'
}
export default {
  WXCreateGameClubButton(conf) {
    const config = JSON.parse(conf);
    config.style = JSON.parse(config.styleRaw);
    if (config.style.fontSize === 0) {
      config.style.fontSize = undefined;
    }
    config.type = typeEnum[config.type];
    config.icon = iconEnum[config.icon];
    const id = new Date().getTime().toString(32)+Math.random().toString(32);
    gameClubs[id] = wx.createGameClubButton(config);
    return id;
  },
  WXGameClubButtonDestroy(id) {
    if (gameClubs[id]) {
      gameClubs[id].destroy();
      delete gameClubs[id];
    } else {
      printErrMsg(id);
    }
  },
  WXGameClubButtonHide(id) {
    if (gameClubs[id]) {
      gameClubs[id].hide();
    } else {
      printErrMsg(id);
    }
  },
  WXGameClubButtonShow(id) {
    if (gameClubs[id]) {
      gameClubs[id].show();
    } else {
      printErrMsg(id);
    }
  },
  WXGameClubButtonAddListener(id, key) {
    if (gameClubs[id]) {
      gameClubs[id][key](function(e) {
        moduleHelper.send('OnGameClubButtonCallback', JSON.stringify({
          callbackId: id,
          errMsg: key
        }));
      })
    } else {
      printErrMsg(id);
    }
  },
  WXGameClubButtonRemoveListener(id, key) {
    if (gameClubs[id]) {
      gameClubs[id][key]();
    } else {
      printErrMsg(id);
    }
  },
  WXGameClubButtonSetProperty(id, key, value) {
    if (gameClubs[id]) {
      gameClubs[id][key] = value;
    }
  },
  WXGameClubStyleChangeInt(id, key, value) {
    if (gameClubs[id]) {
      gameClubs[id]["style"][key] = value;
    }
  },
  WXGameClubStyleChangeStr(id, key, value) {
    if (gameClubs[id]) {
      gameClubs[id]["style"][key] = value;
    }
  }
}
