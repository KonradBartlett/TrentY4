<?php 
 //include library here
 
 
  $errors=array();
  //get and validate the users name, must have length and at least one space
  $name=$_POST['name'];
  if(strlen($name) < 0 || strpos($name, " ")===FALSE)
    $errors[]="<h2>You must enter a valid name</h2>";  
    
  //get and validate the users email
  $email = $_POST['email'];
  if (!filter_var($email, FILTER_VALIDATE_EMAIL)) 
    $errors[]="<h2>You must enter a valid email</h2>";  
   
   
  //make sure terms are agreed to (Note: not in array at all if not selected)
  $agree = $_POST['agree'] ?? null;
  if($agree ==null)
   $errors[]="<h2>You must agree to the terms and conditions</h2>";
 
  

  //make sure the user chose something other then select one
  $choice = $_POST['movie'];
  if($choice==0)
    $errors[]="<h2>You choose a movie</h2>";
  
  
   //make sure terms are agreed to (Note: not in array at all if not selected)
  $country = $_POST['country'] ?? null;
    

  // No errors...do database work
  if(sizeof($errors)==0){
  //call database connection function
  
  //do insert
  
  //do update
  
  
  
  
  
  
  
  
  
  
      
  }
?>
      

<!DOCTYPE html>
<html lang="en">
<head>
  <!-- head includes goes here -->
  <?php 
    $PAGE_TITLE = "Processing the Vote";
    include 'includes/head_includes.php';  
  ?>
  

</head>
<body>
  <div id="container">
	 <!--header goes here -->
   <?php include 'includes/header.php'; ?>
    <main>
      <?php
        foreach ($errors as $error)
          echo $error;
      ?>
      
    </main>
  
  <!-- footer goes here- -->
  <?php include 'includes/footer.php'; ?>
  </div>
    
</body>
</html>