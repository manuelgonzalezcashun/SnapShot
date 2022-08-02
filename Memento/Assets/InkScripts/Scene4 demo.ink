INCLUDE globals.ink
{Name("")}
We arrived to the park
Flower looks very happy to be here

{Name("Flower")}
When I was little, I used to come to the park all the time 

{Name(name)}
Oh. So you come here often?

{Name("Flower")}
Not much anymore
I'm too busy now

{Name(name)}
Oh that's a bummer.

~phoneNotif = true
~TEXT(phoneNotif)
{Name("")}
Suddenly a dog came to the park and Flower fell in love instantly.

{Name("Flower")}
LOOK OVER THERE! That dog is so cute!
Quick take a picture {name}

{Name(name)} 
You want a picture of the dog?

{Name("Flower")}
Yes! Did you forget how to take a picture?
Just bring your reticle/mouse over the dog to take a picture of it!

{Name(name)}
I know how to use a camera {("Flower")}!

{Name("Flower")}
Well hurry up before it runs away!
~HidePanel = true
~HIDE(HidePanel)
-> Continue

===Continue===

{Name("Flower")}
Look how cute this puppy is 

{Name(name)}
The puppy is very cute

{Name("Flower")}
You should keep that picture
That way you don't forget about today
{Name(name)}
Sounds like a good idea.
{Name("Flower")}
I think we should be going. it's getting late.
{Name(name)}
Sounds good. Lets go home.
~didTextPlay = true
~VAR(didTextPlay)
-> DONE