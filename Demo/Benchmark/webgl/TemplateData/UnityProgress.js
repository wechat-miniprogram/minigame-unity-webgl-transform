function UnityProgress(gameObject, progress) {
  if (!gameObject.Module)
    return;
  if (!gameObject.logo) {
    gameObject.logo = document.createElement("div");
    gameObject.logo.className = "logo " + gameObject.Module.splashScreenStyle;
    gameObject.container.appendChild(gameObject.logo);
  }
  if (!gameObject.progress) {    
    gameObject.progress = document.createElement("div");
    gameObject.progress.className = "progress " + gameObject.Module.splashScreenStyle;
    gameObject.progress.empty = document.createElement("div");
    gameObject.progress.empty.className = "empty";
    gameObject.progress.appendChild(gameObject.progress.empty);
    gameObject.progress.full = document.createElement("div");
    gameObject.progress.full.className = "full";
    gameObject.progress.appendChild(gameObject.progress.full);
    gameObject.container.appendChild(gameObject.progress);
  }
  gameObject.progress.full.style.width = (100 * progress) + "%";
  gameObject.progress.empty.style.width = (100 * (1 - progress)) + "%";
  if (progress == 1)
    gameObject.logo.style.display = gameObject.progress.style.display = "none";
}