 <html>

	<head>

		<!-- This is how you comment in HTML, typically you need some information here I will leave that to your COIS 3420 instructor to teach you -->

	</head>


	<body>

		
		
		<center>
			<H1> Welcome To This Fancy Form</H1> <br>
			
			<!-- This is where the form starts -->

			<!-- the action = index.php, this is only the case because the PHP script is in the same file as this one -->

			<!--we are setting the method to be post, 1% bonus point if you email me one page (double spaced 12 point font regarding the difference between a get and a post within one week of this lab) -->
			<form action="index.php" method="post">
			
			
				Firstname: <input type="text" name="firstname">	<br> <br>
				Lastname: <input type="text" name="lastname">	<br> <br>
				Age: <input type="number" name="age" min="13" max="100" id="age"> <br> <br>

				<input type="submit">	

		</center>

			</form>



	</body>




</html>

<!-- Below is the opening PHP tag, notice how we utilized the standard way to comment in HTML because before we input the PHP tag we are still in the html portion of this file. DESPITE the fact that it is a .php file we have html within it -->
<?php


/* 


This is a block comment in PHP, we do it the same way in C# 
------------------------------------------------------------------------------------------------------
We are going to include the PHP script withint the actual index.php file (right here) for convenience. Typically you would link to this script file by setting the action = "someOtherFileWithAPHPScript" we do it that way for the sake of making it easier to edit later on, when you learn web development the code file can get very long and it is much easier to have it in another file. For now embedding within it like this is fine.

------------------------------------------------------------------------------------------------------

*/ 

//Step 0: Load HTML elements as PHP variables:

/*

We can achieve this for firstname by doing the following 

$firstname is a PHP variable we need to get value from the element name in PHP we can do that when the submit button is clicked: by utilizing the @$_POST['']; 

What goes in between the single quotations is the HTML element name. In this case it is firstname.

Complete the same steps for the next two form elements (lastname, and age)


*/

$firstName = @$_POST['firstname'];




//Step 1: Connect (refer to the slides and the lab handout):



//Step 2: Check if we connected successfully (refer to the slides):




//Step 3: Execute a query while checking if it executed correctly (refer to the slides):




//Step 4: Close connection (refer to the slides):








/*
-----------------------------------------------------------------------------------------------------
Closing PHP tag below, this marks the end of the PHP script, below it we are back to HTML it won't recognize it as a PHP script without these tags.
-----------------------------------------------------------------------------------------------------
*/ 
?>