let angle = 0;
let kitten;
let fire;
var vid;
let ck;

function preload() {
  //noise = loadImage('kitten0.jpg');
  ck = loadModel('CK.obj');
  vid = createVideo(["boy.mp4"]);
  fire = loadImage('fire.jpg');
  vid.elt.muted = false;
  vid.loop();
  vid.hide();
}

function setup() {
  createCanvas(1000, 1000, WEBGL);
}

function draw() {
  background(0);
  ambientLight(50, 50, 60);
  directionalLight(100, 50, 60, 0, -100, 0);
  rotateX(angle);
  rotateY(angle * 1.3);
  rotateZ(angle * 0.7);
  translate(0, 0, 0);
  texture(vid);
  box(100);
  translate(angle * 20, 0, 0);
  texture(fire);
  model(ck);
  angle += 0.03;
}
