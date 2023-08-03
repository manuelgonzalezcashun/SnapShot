INCLUDE globals.ink

Hello! #speaker: Tola #icon: Tola_neutral
I am testing the new Dialogue System.
or am I? 
What do you think?
* I think you're lying! -> lying #speaker: Sam
* I think you're telling the truth -> truth #speaker: Sam
* I don't even know -> huh #speaker: Sam

===lying===
~relationship_score -= 1 
~playSound("relScoreRemove")
How Dare You! #speaker: Tola #icon: Tola_sad 
-> END

===truth===
~relationship_score += 1
~playSound("relScoreAdd")
Look's like we will be friends... #speaker: Tola #icon: Tola_happy
* [I don't want to be your friend!] -> lying
* [Sounds good to me!] -> GoodEnding

===huh===
What do you mean you don't know??? #speaker: Tola 
I'll give you another chance.
What do you think?
* [I think you're lying!] -> lying
* [I think you're telling the truth] -> truth
+ [I don't even know] -> huh

===GoodEnding===
~relationship_score += 5 
~playSound("relScoreAdd")
Tola and the player proceed to have a picnic. #speaker: Narrator 
-> END

