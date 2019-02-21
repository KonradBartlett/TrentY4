# "Database code" for the DB Forum.
#These are the imports that are required.
import datetime
import psycopg2
#setting a variable called DBNAME = to the name of the database, the database has already created and is called forum.
DBNAME = "forum"

#Below is just the default first post, you do not need to worry about it.
POSTS = [("This is the first post.", datetime.datetime.now())]

def get_posts():
	#Return all posts from the 'database', most recent first.
	#The code below is commented out, it is simply reversing the order of the posts and displaying them temporariliy for the user, ideally we would like to create a permanent database not just display it to the user then lose all the information once the user closes the window.

  #return reversed(POSTS)
  #Step 1: Connect to the database:
  db = psycopg2.connect(database=DBNAME)   #completed

  #Step 2: Create a cursor object:

  cursor = db.cursor()

  #Step 3: using the cursor object SELECT everything from the database (use a SELECT * FROM posts to do so):
  #hint it may be useful to actually order by time in descending order (so that the most recent post is on top)

  cursor.execute("SELECT * FROM posts ORDER BY id DESC;")

  #Step 4: Utilize a fetchall statement in order to grab the entire resulting table from the query

  db.close()

  #Step 5: Return the resulting table (i.e., if you used data = cursor.fetchall() then you would need to return(data))

  return(result)

  #Step 6: Close the connection


  result = cursor.fetchall()


def add_posts():

	 """Add a post to the 'database' with the current timestamp."""
	 #Commented out becasue we would like to build a persistent database not simply output the posts.
  	#POSTS.append((content, datetime.datetime.now()))

	#Step 1: Connect to the database:

	db = psycopg2.connect(database=posts)

	#Step 2: Create the cursor object:

    cursor = db.cursor()

	#Step 3: Using the cursor object execute a query that will input the content into the database. Remebmer the posts table has already been created and there are two columns date and content (TEXT or VARCHAR)
	#You do NOT need to actually insert the time into the database table, it will be done automatically.

    cursor.execute("INSERT INTO posts (content, id) VALUES ('Hi', 3);")

	#Step 4: Commit the change to the database:

    db.commit()

	#Step 5: Close the connection:

    db.close()
