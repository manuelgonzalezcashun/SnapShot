INCLUDE globals.ink
#background: bg0
Hello! #speaker: Aisha #icon: default
I am testing the new Dialogue System.
or Am i? 
What do you think?
* [I think you're lying!] -> lying
* [I think you're telling the truth] -> truth
* [I don't even know] -> huh

===lying===
#background: bg1 #icon: Flower_angry
~ relationship_score = 0
How Dare You!
-> DONE

===truth===
#background: bg2 #icon: Flower_happy
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