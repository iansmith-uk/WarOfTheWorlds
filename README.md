# War of the Worlds


## What does the project do?

This project was created as I was tasked to create an application which counts the number of words in War of the Worlds for a job interview a long time ago.

The process is simple:
- The software reads a file (this is hard coded to be war of the worlds, but it can be any text file)
- Punctuation is removed (full stops etc.)
- The text within the file is then split into an array of words
- Inside of a loop, the software checks a Dictionary to see if the word has been seen previous
  - If this is a new word, it is added to the Dictionary with a value of 1
  - If this has already been seen, we update the value in the dictionary by 1 (to keep a count)
- an output file is created with a list of unique words and how many times it has been seen within the text

## How do I use it? (installation instructions)

Open the solution in Visual Studio and change the "inputPath" variable with the location of the file you wish to read. Run the application and enjoy.
