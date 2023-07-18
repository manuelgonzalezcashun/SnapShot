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
~relationship_score -= 1
#icon: Flower_angry
~changeBackground("bg1")
How Dare You!
-> END

===truth===
~relationship_score += 1
#icon: Flower_happy
~changeBackground("bg2")
Look's like we will be friends...
* [I don't want to be your friend!] -> lying
* [Sounds good to me!] -> GoodEnding

===huh===
What do you mean you don't know???
I'll give you another chance.
What do you think?
* [I think you're lying!] -> lying
* [I think you're telling the truth] -> truth
+ [I don't even know] -> huh

===GoodEnding===
~relationship_score += 5
Flower and the player proceed to have a picnic.
-> END