OscIn oin;
if( me.args() ) me.arg(0) => Std.atoi => oin.port;
else 7001 => oin.port;
oin.listenAll();

OscMsg msg;
SinOsc a => SinOsc b => dac;

while(true)
{
    oin => now;
    
    while( oin.recv(msg) )
    {
        msg.getString(0) => string whatPlaying;
        <<< whatPlaying >>>;
        if (whatPlaying == "isNearRed1") 
        {
            200 => a.freq;
            250 => b.freq;
            0.8 => b.gain;
            2 => b.sync;
            0.5 :: second => now;   
        } else if (whatPlaying == "isNearRed2")
        {
            300 => a.freq;
            350 => b.freq;
            0.8 => b.gain;
            2 => b.sync;
            0.5 :: second => now;
        }
        else if (whatPlaying == "isNearRed3")
        {
            400 => a.freq;
            450 => b.freq;
            0.8 => b.gain;
            2 => b.sync;
            0.5 :: second => now;   
        }else if (whatPlaying == "isInRed")
        {
            550 => b.freq;
            500 => a.freq;
            0.8 => b.gain;
            2 => b.sync;
            0.5 :: second => now;
        } else if (whatPlaying == "outerLayerOne")
        {
            0 => b.gain;
            ModalBar viol => NRev a => dac;
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(110) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        } else if (whatPlaying == "outerLayerTwo")
        {
            0 => b.gain;
            ModalBar viol => NRev a => dac;
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(90) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        } else if (whatPlaying == "outerLayerThree")
        {
            0 => b.gain;
            ModalBar viol => NRev a => dac;
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(80) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        } else if (whatPlaying == "outerLayerFour")
        {
            0 => b.gain;
            ModalBar viol => NRev a => dac;
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(60) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        } else if (whatPlaying == "isTumor")
        {
            0 => b.gain;
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
        } else if (whatPlaying == "inTheArea")
        {
            0 => b.gain;
            Rhodey voc => JCRev r => dac;
            220.0 => voc.freq;
            0.8 => voc.gain;
            .8 => r.gain;
            .2 => r.mix;
            
            [ 0, 2, 4, 7, 9 ] @=> int scale[];
            scale[ 1 ] => int freq;
            
            Std.mtof( ( 33 + Math.random2(0,1) * 12 + freq ) ) => voc.freq;
            Math.random2f( 0.6, 0.8 ) => voc.noteOn;
            
            // note: Math.randomf() returns value between 0 and 1
            if( Math.randomf() > 0.85 )
            { 1000::ms => now; }
            else if( Math.randomf() > .85 )
            { 500::ms => now; }
            else if( Math.randomf() > .1 )
            { .250::second => now; }
            else
            {
                0 => int i;
                2 * Math.random2( 1, 3 ) => int pick;
                0 => int pick_dir;
                0.0 => float pluck;
                
                for( ; i < pick; i++ )
                {
                    Math.random2f(.4,.6) + i*.035 => pluck;
                    pluck + -0.02 * (i * pick_dir) => voc.noteOn;
                    !pick_dir => pick_dir;
                    250::ms => now;
                }
            }
        } 
    }
}