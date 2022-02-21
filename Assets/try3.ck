OscIn oin;
if( me.args() ) me.arg(0) => Std.atoi => oin.port;
else 7001 => oin.port;
oin.listenAll();

OscMsg msg;

while(true)
{
    oin => now;
    
    while( oin.recv(msg) )
    {
        msg.getString(0) => string whatPlaying;
        <<< whatPlaying >>>;
        if (whatPlaying == "isNearRed") 
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
        } else if (whatPlaying == "isInRed")
        {
            SinOsc m => SinOsc c => dac;
            550 => c.freq;
            500 => m.freq;
            300 => m.gain;
            2 => c.sync;
            0.5 :: second => now;
        } else if (whatPlaying == "isTumor")
        {
            SinOsc sinO => dac;
            Std.mtof(150) => sinO.freq;
            0.5 :: second => now;
        } else if (whatPlaying == "area60")
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
        } else if (whatPlaying == "area70")
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
        } else if (whatPlaying == "area80")
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
        } else if (whatPlaying == "area90")
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
        } else if (whatPlaying == "inTheArea")
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