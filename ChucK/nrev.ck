function void bar()
{
    ModalBar viol => NRev a => dac;
    [10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 100] @=> int scale[];
    1  => a.gain;
    0.3 => a.mix;
    for (0 => int i; i < scale.cap(); i++)
    {
        Std.mtof(scale[i]) => viol.freq;
        //0.4 => viol.strikePosition;
        //0.4 => viol.strike;
        6 => viol.preset;
        1 => viol.noteOn;
        Impulse imp => ResonZ filt => dac;
        100.0 => filt.Q;
        500 => filt.freq;
        100.0 => imp.next;
        filt + viol => dac;
        0.1 :: second => now;
        1 => viol.noteOff;
        0.4 :: second => now;
    }
}

fun void vessel()
{
    Impulse imp => ResonZ filt => dac;
    
    for (0 => int i; i < 3; i++) {
        100.0 => filt.Q;
        500 => filt.freq;
        100.0 => imp.next;
        0.1 :: second => now;
        1000 => filt.freq;
        100.0 => imp.next;
        0.1 :: second => now;
        250 => filt.freq;
        100.0 => imp.next;
        0.1 :: second => now;
    }
    
    for (0 => int i; i < 3; i++) {
        100.0 => filt.Q;
        1500 => filt.freq;
        100.0 => imp.next;
        0.1 :: second => now;
        2000 => filt.freq;
        100.0 => imp.next;
        0.1 :: second => now;
        1000 => filt.freq;
        100.0 => imp.next;
        0.1 :: second => now;
    }
    
    for (0 => int i; i < 3; i++) {
        100.0 => filt.Q;
        3500 => filt.freq;
        100.0 => imp.next;
        0.1 :: second => now;
        4000 => filt.freq;
        100.0 => imp.next;
        0.1 :: second => now;
        3000 => filt.freq;
        100.0 => imp.next;
        0.1 :: second => now;
    }
}

spork ~bar();

while (true) 1::second => now;
