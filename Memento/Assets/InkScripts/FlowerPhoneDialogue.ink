INCLUDE globals.ink

Hey Mikey!!!
How are you doing?

* I'm doing great!!! -> Happy
* I'm a little upset right now -> Upset

=== Happy ===
Thats Great!!! Lets Hang out!!!
-> ChangeDialogue

===Upset===
Oh Im sorry to hear that well hopefully hanging out will make you feel better 
-> ChangeDialogue

===ChangeDialogue===
~didTextPlay = true
This text played

-> END