<?php

$direx = explode("/", getcwd());
DEFINE ('DOCROOT', '/'.$direx[1].'/'.$direx[2].'/'); // home/username/
DEFINE ('WEBROOT', '/'.$direx[1].'/'.$direx[2].'/'.$direx[3].'/'); // home/username/public_html/


function dbconnect(){
   // Load configuration as an array. Use the actual location of your configuration file
    //$config = parse_ini_file(DOCROOT.'config.ini');
    //Note: on loki, you file should be located in the pwd folder (which should be in your user directory)
    $config = parse_ini_file(DOCROOT.'pwd/config.ini'); 
 
 
    //create connection dsn
   $dsn = "mysql:host={$config['domain']};dbname={$config['dbname']};charset={$config['charset']}";
    
    //set options array for connection
    $options = [
        PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
        PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
        PDO::ATTR_EMULATE_PREPARES   => false,
    ];
    
    //make database object
    try {
        $pdo = new PDO($dsn, $config['username'], $config['password'], $options);
    } catch (\PDOException $e) {
         throw new \PDOException($e->getMessage(), (int)$e->getCode());
    }
    
    return $pdo;
    
}    


/*############################################################
    Functions for working with Files
##############################################################*/

function createFilename($file, $path, $prefix,$uniqueID){	
	$filename = $_FILES[$file]['name'];
	$exts = explode(".", $filename);
	$ext = $exts[count($exts)-1];
	$filename = $prefix.$uniqueID.".".$ext;
	$newname=$path.$filename;
	return $newname;
}


function checkAndMoveFile($file, $limit, $newname){	
	//modified from http://www.php.net/manual/en/features.file-upload.php
	try{
	    // Undefined | Multiple Files | $_FILES Corruption Attack
	    // If this request falls under any of them, treat it invalid.
	    if(!isset($_FILES[$file]['error']) || is_array($_FILES[$file]['error'])) {
	        throw new RuntimeException('Invalid parameters.');
	    }

	    // Check Error value.
	    switch ($_FILES[$file]['error']) {
	        case UPLOAD_ERR_OK:
	            break;
	        case UPLOAD_ERR_NO_FILE:
	            throw new RuntimeException('No file sent.');
	        case UPLOAD_ERR_INI_SIZE:
	        case UPLOAD_ERR_FORM_SIZE:
	            throw new RuntimeException('Exceeded filesize limit.');
	        default:
	            throw new RuntimeException('Unknown errors.');
	    }

	    // You should also check filesize here. 
	    if ($_FILES[$file]['size'] > $limit) {
	        throw new RuntimeException('Exceeded filesize limit.');
	    }

	    // Check the File type
	    if (exif_imagetype( $_FILES[$file]['tmp_name']) != IMAGETYPE_GIF 
	    	and exif_imagetype( $_FILES[$file]['tmp_name']) != IMAGETYPE_JPEG
	    	and exif_imagetype( $_FILES[$file]['tmp_name']) != IMAGETYPE_PNG){
	        
	        	throw new RuntimeException('Invalid file format.');
	    }
	
	    // $newname should be unique and tested
	    if (!move_uploaded_file($_FILES[$file]['tmp_name'], $newname)){
	        throw new RuntimeException('Failed to move uploaded file.');
	    }
	
	    echo 'File is uploaded successfully.';

	} catch (RuntimeException $e) {
	
	    echo $e->getMessage();
	
	}
	
}

  
?>