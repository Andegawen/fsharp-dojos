open MarkovBotModule

let sample = """
I see trees of green, red roses, too,
I see them bloom, for me and you
And I think to myself
What a wonderful world.
I see skies of blue, and clouds of white,
The bright blessed day, the dark sacred night
And I think to myself
What a wonderful world.
The colors of the rainbow, so pretty in the sky,
Are also on the faces of people going by.
I see friends shaking hands, sayin', "How do you do?"
They're really sayin', "I love you."
I hear babies cryin'. I watch them grow.
They'll learn much more than I'll ever know
And I think to myself
What a wonderful world
Yes, I think to myself
What a wonderful world"""

[<EntryPoint>]
let main argv =
    printfn "%A" (generateFrom "I" sample 2)
    printfn "%A" (getWords sample)
    0 // return an integer exit code