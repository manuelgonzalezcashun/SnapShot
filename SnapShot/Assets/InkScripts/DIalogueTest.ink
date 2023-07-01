INCLUDE globals.ink

Hello! #speaker: Manuel
I am testing the new Dialogue System.
or Am i? 
What do you think?
* [I think you're lying!] -> lying
* [I think you're telling the truth] -> truth
* [I don't even know] -> huh

===lying===
~ relationship_score = 0
How Dare You!
-> DONE

===truth===
~ relationship_score = 5
Look's like we will be friends...
-> DONE

===huh===
What do you mean you don't know???
I'll give you another chance.
What do you think?
* [I think you're lying!] -> lying
* [I think you're telling the truth] -> truth
+ [I don't even know] -> huh