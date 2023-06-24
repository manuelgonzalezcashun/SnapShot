VAR sentenceNum = 0
-> sentence1
===sentence1===
~sentenceNum = 0
Hey StarRail
-> sentence2

===sentence2===
~sentenceNum = 1
How are you doing?
0
-> choices

===choices===
* [I'm doing good]  -> happy
* [I'm sad right now] -> sad

===happy===
~sentenceNum = 2
That's great to hear!
-> sentence3

===sad===
~sentenceNum = 2
Oh Im sorry to hear that 
-> sentence3

===sentence3===
~sentenceNum = 3
I think we should hang out today, so I'm coming over!
0
-> fin

===fin===
->DONE