var camera, scene, renderer;
var cameraControls;
var clock = new THREE.Clock();
var ambientLight, light;

function init() {
    var canvasWidth = window.innerWidth * 0.9;
    var canvasHeight = window.innerHeight * 0.9;

    // CAMERA
    camera = new THREE.PerspectiveCamera(45, window.innerWidth / window.innerHeight, 1, 80000);
    camera.position.set(-1, 1, 3);
    camera.lookAt(0, 0, 0);

    // LIGHTS
    light = new THREE.DirectionalLight(0xFFFFFF, 0.7);
    light.position.set(1, 1, 1);
    light.target.position.set(0, 0, 0);
    light.target.updateMatrixWorld();

    var ambientLight = new THREE.AmbientLight(0x111111);

    // RENDERER
    renderer = new THREE.WebGLRenderer({ antialias: true });
    renderer.setSize(canvasWidth, canvasHeight);
    renderer.setClearColor(0xAAAAAA, 1.0);

    renderer.gammaInput = true;
    renderer.gammaOutput = true;

    // Add to DOM
    var container = document.getElementById('container');
    container.appendChild(renderer.domElement);

    // CONTROLS
    cameraControls = new THREE.OrbitControls(camera, renderer.domElement);
    cameraControls.target.set(0, 0, 0);

    // OBJECTS

    // Cubo
    var verticesCubo = [
        new THREE.Vector3(-0.1, -0.2, -0.1),
        new THREE.Vector3(0.1, -0.2, -0.1),
        new THREE.Vector3(0.1, 0.2, -0.1),
        new THREE.Vector3(-0.1, 0.2, -0.1),
        new THREE.Vector3(-0.1, -0.2, 0.1),
        new THREE.Vector3(0.1, -0.2, 0.1),
        new THREE.Vector3(0.1, 0.2, 0.1),
        new THREE.Vector3(-0.1, 0.2, 0.1)
    ];

    var carasCubo = [
        new THREE.Face3(0, 1, 2),
        new THREE.Face3(0, 2, 3),
        new THREE.Face3(4, 6, 5),
        new THREE.Face3(4, 7, 6),
        new THREE.Face3(0, 4, 5),
        new THREE.Face3(0, 5, 1),
        new THREE.Face3(2, 6, 7),
        new THREE.Face3(2, 7, 3),
        new THREE.Face3(0, 3, 7),
        new THREE.Face3(0, 7, 4),
        new THREE.Face3(1, 5, 6),
        new THREE.Face3(1, 6, 2)
    ];

    var geometriaCubo = new THREE.Geometry();
    geometriaCubo.vertices = verticesCubo;
    geometriaCubo.faces = carasCubo;

    var materialCubo = new THREE.MeshBasicMaterial({ color: 0x2A0800 });
    var cubo = new THREE.Mesh(geometriaCubo, materialCubo);
    cubo.position.set(0, 0, 0); // Ajusta la posición del cubo

    // Pirámide
    var alturaPiramide = 0.5;
    var geometriaPiramide = new THREE.CylinderGeometry(0, 0.4, alturaPiramide, 4, 1); // Parámetros: radio superior, radio inferior, altura, número de segmentos, número de lados en la parte superior
    var geometriaPiramide2 = new THREE.CylinderGeometry(0, 0.3, 0.4, 4, 1);
    var materialPiramide = new THREE.MeshBasicMaterial({ color: 0x033200 });
    var piramide = new THREE.Mesh(geometriaPiramide, materialPiramide);
    piramide.position.set(0, 0.4, 0); // Ajusta la posición de la pirámide

    //pirámide2
    var piramide2 = new THREE.Mesh(geometriaPiramide2, materialPiramide);
    piramide2.position.set(0, 0.6, 0);

    // Esfera
    var radioEsfera = 0.03;
    var segmentosEsfera = 32;
    var anillosEsfera = 16;
    var geometriaEsfera = new THREE.SphereGeometry(radioEsfera, segmentosEsfera, anillosEsfera);

    var materialEsfera = new THREE.MeshBasicMaterial({ color: 0x0000FF });
    var esfera = new THREE.Mesh(geometriaEsfera, materialEsfera);
    esfera.position.set(0.4, 0.12, 0); // Ajusta la posición de la esfera

    var materialEsfera2 = new THREE.MeshBasicMaterial({ color: 0xFF0000 });
    var esfera2 = new THREE.Mesh(geometriaEsfera, materialEsfera2);
    esfera2.position.set(-0.4, 0.12, 0); // Ajusta la posición de la esfera

    var materialEsfera3 = new THREE.MeshBasicMaterial({ color: 0x00FF00 });
    var esfera3 = new THREE.Mesh(geometriaEsfera, materialEsfera3);
    esfera3.position.set(0, 0.12, -0.4); // Ajusta la posición de la esfera

    var materialEsfera4 = new THREE.MeshBasicMaterial({ color: 0xECFF00 });
    var esfera4 = new THREE.Mesh(geometriaEsfera, materialEsfera4);
    esfera4.position.set(0, 0.12, 0.4); // Ajusta la posición de la esfera

    var materialEsfera5 = new THREE.MeshBasicMaterial({ color: 0xECFF00 });
    var esfera5 = new THREE.Mesh(geometriaEsfera, materialEsfera5);
    esfera5.position.set(0.3, 0.38, 0); // Ajusta la posición de la esfera

    var materialEsfera6 = new THREE.MeshBasicMaterial({ color: 0x00FF00 });
    var esfera6 = new THREE.Mesh(geometriaEsfera, materialEsfera6);
    esfera6.position.set(-0.3, 0.38, 0); // Ajusta la posición de la esfera

    var materialEsfera7 = new THREE.MeshBasicMaterial({ color: 0xFF0000 });
    var esfera7 = new THREE.Mesh(geometriaEsfera, materialEsfera7);
    esfera7.position.set(0, 0.38, -0.3); // Ajusta la posición de la esfera

    var materialEsfera8 = new THREE.MeshBasicMaterial({ color: 0x0000FF });
    var esfera8 = new THREE.Mesh(geometriaEsfera, materialEsfera8);
    esfera8.position.set(0, 0.38, 0.3); // Ajusta la posición de la esfera


// Crear un octaedro
var geometry = new THREE.OctahedronGeometry();
var material = new THREE.MeshBasicMaterial({ color: 0xECFF00 });
var octahedron = new THREE.Mesh(geometry, material);
octahedron.scale.set(0.1, 0.1, 0.1);
octahedron.position.set(0,0.88,0);

    // SCENE
    scene = new THREE.Scene();
    scene.add(light);
    scene.add(ambientLight);

    scene.add(cubo);
    scene.add(piramide);
    scene.add(piramide2);
    scene.add(esfera);
    scene.add(esfera2);
    scene.add(esfera3);
    scene.add(esfera4);
    scene.add(esfera5);
    scene.add(esfera6);
    scene.add(esfera7);
    scene.add(esfera8);
    scene.add(octahedron);
}

function animate() {
    window.requestAnimationFrame(animate);
    render();
}

function render() {
    var delta = clock.getDelta();
    cameraControls.update(delta);
    renderer.render(scene, camera);
}

try {
    init();
    animate();
} catch (e) {
    var errorReport = "Your program encountered an unrecoverable error, can not draw on canvas. Error was:<br/><br/>";
    $('#container').append(errorReport + e);
}
