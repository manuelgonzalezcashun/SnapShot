INCLUDE globals.ink
{Name(name)}
Hey Flower. Nice to show up unnanounced like that.
{Name("Flower")}
Hahaha I just wanted to hang out with a friend today, that's all.
{Name(name)}
Really?
{Name("Flower")}
Yeah Really... heh heh...
{Name(name)}
Flower.
Why are you really here?
{Name("Flower")}
...
I needed help to do my homework
{Name(name)}
I knew it!

{Name("")}
("Well I should get my homework out of the way to enjoy the rest of the day")

{Name(name)}
Alright. How about we get started on our homework then?

{Name("Flower")}
Yes! Thank you so much! 
-> transition 

===transition===
{Name("")}
Flower and I spent a while doing homework -> Coffee

===Coffee==
{Name("Flower")}
Wow we finally finished our homework.
Say, why don't we go out to get some coffee.
There's a little spot that I like. 

{Name("")}
("I could use a coffee")

{Name(name)}
I would like some coffee. Let's  go

~didTextPlay = true
~VAR(didTextPlay)
->DONE

