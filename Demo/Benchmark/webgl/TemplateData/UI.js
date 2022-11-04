var UI= {
  init: function(container, onQuit){
    this.container = container;
    this.main = document.createElement("div");
    this.main.id = "overlay";

    this.main.style.bottom = "0px";
    this.container.appendChild(this.main);
    // this.createButton("Reload with #no-cache");
    this.createButton("X", function() {
      onQuit();
      UI.container.removeChild(UI.main);
    });
    if (!UnityLoader.SystemInfo.mobile)
      this.createButton("Enable Fullscreen", function(){
        gameInstance.SetFullscreen(1);
      });
  },
  createButton: function (text, callback) {
    var button = document.createElement("button");
    button.className = "button";
    var t = document.createTextNode(text);
    button.appendChild(t);
    button.addEventListener("click", callback);
    this.main.appendChild(button);
  },
  createSection: function(title) {
    var section = document.createElement("p");
    section.id = "section";
    section.innerText = title;

    var content = document.createElement("p");
    content.id = "section-content";

    section.appendChild(content);
    this.main.appendChild(section);

    return content;
  }
}