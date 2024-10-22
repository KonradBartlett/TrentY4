var runtime = new ShaderFrogRuntime(),
    width = 800, height = 600,
    clock = new THREE.Clock(),
    camera, cubeCamera, scene, renderer, meshTop, meshBottom, cubeCamera, leftSphere, rightSphere;



init();
animate();

function init() {

    scene = new THREE.Scene();

    // Cameras
    camera = new THREE.PerspectiveCamera( 50, width / height, 1, 10000 );
    camera.position.z = 100;
    scene.add( camera );
    runtime.registerCamera( camera );

    cubeCamera = new THREE.CubeCamera( 0.1, 10000, 128 );
    scene.add( cubeCamera );

    // Main object
    var topGeometry = new THREE.SphereGeometry( 20, 10, 10 );
    meshTop = new THREE.Mesh( topGeometry );
    meshTop.position.y = 20;
    scene.add( meshTop );

    // Second main object
    var bottomGeometry = new THREE.SphereGeometry( 20, 10, 10 );
    meshBottom = new THREE.Mesh( bottomGeometry );
    meshBottom.position.y = -20;
    scene.add( meshBottom );
	
	var light = new THREE.PointLight( 0xff0000, 1, 100 );
	light.position.set( 50, 50, 50 );
	scene.add( light )

    // Decorative objects
    var other = new THREE.SphereGeometry( 10, 20, 50, 50 );
    leftSphere = new THREE.Mesh(other, new THREE.MeshBasicMaterial({
        color: 0xff0000
    }));
    leftSphere.position.x -= 45;
    scene.add(leftSphere);

    var cyl = new THREE.CylinderGeometry( 1, 1, 100, 5 );
    var cylMesh =  new THREE.Mesh(cyl, new THREE.MeshBasicMaterial({
        color: 0x0044ff
    }));
    cylMesh.position.x += 45;
    scene.add(cylMesh);

    var cyl2 = new THREE.CylinderGeometry( 1, 1, 100, 5 );
    var cylMesh2 =  new THREE.Mesh(cyl2, new THREE.MeshBasicMaterial({
        color: 0x0044ff
    }));
    cylMesh2.position.x -= 45;
    scene.add(cylMesh2);

    var other2 = new THREE.SphereGeometry( 10, 20, 50, 50 );
    rightSphere = new THREE.Mesh(other2, new THREE.MeshBasicMaterial({
        color: 0x00ff00
    }));
    rightSphere.position.x += 45;
    scene.add(rightSphere);

    renderer = new THREE.WebGLRenderer();
    renderer.setSize( width, height );

    document.getElementById( 'canvas' ).appendChild( renderer.domElement );

}

function animate() {

    requestAnimationFrame( animate );
    render();

}

function render() {

    meshTop.rotation.x += 0.01;
    meshTop.rotation.y += 0.02;

    var time = clock.getElapsedTime();

    runtime.updateShaders( time );

    leftSphere.position.y = 40 * Math.sin( new Date() * 0.001 );
    rightSphere.position.y = -40 * Math.sin( new Date() * 0.001 );

    meshTop.visible = false;
    cubeCamera.updateCubeMap( renderer, scene );
    meshTop.visible = true;

    renderer.render( scene, camera );

}
