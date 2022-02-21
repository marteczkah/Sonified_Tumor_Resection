OscIn oin;
OscMsg msg;
7001 => oin.port;

while (true) 
{
    while (oin.recv(msg))
    {
        if (msg.address == "/isNearRed") 
        {
            HevyMetl hm => NRev a => dac;
            [80, 90, 100] @=> int scale[];
            1  => a.gain;
            0.3 => a.mix;
            for (0 => int i; i < scale.cap(); i++)
            {
                Std.mtof(scale[i]) => hm.freq;
                1 => hm.noteOn;
                0.1 :: second => now;
                1 => hm.noteOff;
                0.1 :: second => now;
            }
        } else if (msg.address == "/isInRed")
        {
            SinOsc m => SinOsc c => dac;
            550 => c.freq;
            500 => m.freq;
            300 => m.gain;
            2 => c.sync;
            0.5 :: second => now;
        } else if (msg.address == "/isTumor")
        {
            SinOsc sinO => dac;
            Std.mtof(150) => sinO.freq;
            0.5 :: second => now;
        } else if (msg.address == "/area60")
        {
            ModalBar viol => NRev a => dac;
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(60) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        } else if (msg.address == "/area70")
        {
            ModalBar viol => NRev a => dac;
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(70) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        } else if (msg.address == "/area80")
        {
            ModalBar viol => NRev a => dac;
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(80) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        } else if (msg.address == "/area90")
        {
            ModalBar viol => NRev a => dac;
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(90) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        } else if (msg.address == "/area100")
        {
            ModalBar viol => NRev a => dac;
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(100) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        } 
    }
}
