// 获取uin
export const uid = (length = 20, char = true) => {
  const soup = `${
    char ? '' : '!#%()*+,-./:;=?@[]^_`{|}~'
  }ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789`;
  const soupLength = soup.length;
  const id = [];
  for (let i = 0; i < length; i++) {
    id[i] = soup.charAt(Math.random() * soupLength);
  }
  return id.join('');
};
