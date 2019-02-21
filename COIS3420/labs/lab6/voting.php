<!DOCTYPE html>
<html lang="en">
<head>
  <?php include 'includes/head_includes.php';?>
</head>
<body>
  
  <div id="container">
      <?php include 'includes/header.php';?>
	     <main>
      <form id="voting" name="voting" action="processvote.php" method="post" novalidate>
        <div>
         <label for="name">Name:</label>
         <input type="text" name="name" id="name"  pattern="[A-Za-z-0-9]+\s[A-Za-z-'0-9]+" required /> 
        </div>
       <div>
         <label for="name">Email:</label>
         <input type="text" name="email" id="email" required /> 
        </div>
        <fieldset>
          <legend>Country</legend>
           <input type="radio" name="country" id="canada" value="Canada" />
            <label for="canada">Canada</label>
            
            <input type="radio" name="country" id="us" value="US" />
            <label for="us">US</label>
        </fieldset>
        <div>    
          <label for="movie">Movie Choice:</label>
          <select name="movie" id="movie">
              <option value="0">Select One</option>
            
            
          </select>
        </div>            
            
        <div>    
          <input type="checkbox" name="agree" id="agree" checked="checked" value="Y" required/>
          <label for="agree">Yes, I am 21 years of age or older, and I acknowledge having read and accepted the <a href="rules.html">Official Contest Rules.</a> </label>
        </div>
        <div>    
          <input type="submit" name="submit" value="Submit Vote"/>
        </div>
      </form>
    </main>
    
    <?php include 'includes/footer.php';?>
    
      </div>
    
</body>
</html>