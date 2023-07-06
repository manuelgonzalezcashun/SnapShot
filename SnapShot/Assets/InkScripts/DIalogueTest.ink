INCLUDE globals.ink

~changeBackground("bg0")
Hello! #speaker: Aisha #icon: default
I am testing the new Dialogue System.
or Am i? 
What do you think?
* [I think you're lying!] -> lying
* [I think you're telling the truth] -> truth
* [I don't even know] -> huh

===lying===
#icon: Flower_angry
~playSound("snd1")
~changeBackground("bg1")
~ relationship_score = 0
How Dare You!
-> END

===truth===
#icon: Flower_happy
~playSound("snd2")
~changeBackground("bg2")
~ relationship_score += 1
Look's like we will be friends...
-> END

===huh===
What do you mean you don't know???
I'll give you another chance.
What do you think?
* [I think you're lying!] -> lying
* [I think you're telling the truth] -> truth
+ [I don't even know] -> huh