<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Academy Awards People's Choice Voting</title>
  <link href="css/reset.css" rel="stylesheet" type="text/css">
  <link href="css/style.css" rel="stylesheet" type="text/css">
</head>
<body>
  <div id="container">

    

    <main>
      <form id="voting" name="voting" action="processvote.php" method="post">
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
              <option value="1">Harry Potter and the Prisoner of Azkaban</option>

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
    <footer>
      <span>&copy; 2019 Academy of Motion Picture Arts and Sciences</span>
    </footer>
  </div>

</body>
</html>