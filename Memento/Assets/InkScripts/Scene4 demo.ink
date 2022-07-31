INCLUDE globals.ink
We arrived to the park  #speaker: StarRail
Flower looks very happy to be here


When I was little, I used to come to the park all the time  #speaker: Flower

Oh. So you come here often?  #speaker: StarRail

Not much anymore  #speaker: Flower
I'm too busy now

Oh that's a bummer.  #speaker: StarRail.

~phoneNotif = true
~TEXT(phoneNotif)

Suddenly a dog came to the park and Flower fell in love instantly.

LOOK OVER THERE! That dog is so cute!  #speaker: Flower
Quick take a picture 

You want a picture of the dog?  #speaker: StarRail

Yes! Did you forget how to take a picture?  #speaker: Flower
Just bring your reticle/mouse over the dog to take a picture of it!

I know how to use a camera Flower!  #speaker: StarRail

Well hurry up before it runs away!  #speaker: Flower
~HidePanel = true
~HIDE(HidePanel)
-> Continue

===Continue===

Look how cute this puppy is 

The puppy is very cute  #speaker: StarRail

You should keep that picture  #speaker: Flower
That way you don't forget about today

Sounds like a good idea.  #speaker: StarRail
I think we should be going. it's getting late.  #speaker: Flower
Sounds good. Lets go home.  #speaker: StarRail
~didTextPlay = true
~VAR(didTextPlay)
-> DONE