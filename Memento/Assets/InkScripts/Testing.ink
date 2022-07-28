INCLUDE globals.ink
EXTERNAL BOOL(didTextPlay)
{didTextPlay == false: -> main}

===main===
Mikey went to hang out with Flower.
~ didTextPlay = true
-> DONE

===ChangeScene===
This script is playing
~ BOOL(didTextPlay)
-> DONE

-> END