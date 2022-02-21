OscIn oin;
if( me.args() ) me.arg(0) => Std.atoi => oin.port;
else 7001 => oin.port;

oin.listenAll();

OscMsg msg;
Noise n => LPF f => dac;
while (true) 
{
    oin => now;
    while (oin.recv(msg))
    {
        0.0 => float t;
        msg.getString(0) => string whatPlaying;
        <<< whatPlaying >>>;
        if (whatPlaying == "vessel3") 
        {
            1 => n.gain;
            for (0 => int i; i < 3; i++)
            {
                // sweep the filter resonant frequency
                350.0 + Std.fabs(Math.sin(t)) * 300.0 => f.freq;
                t + .02 => t;
                // advance time
                0.1 :: second => now;
            } 
        } else if (whatPlaying == "vessel2")
        {
            1 => n.gain;
            for (0 => int i; i < 3; i++)
            {
                // sweep the filter resonant frequency
                425.0 + Std.fabs(Math.sin(t)) * 200.0 => f.freq;
                t + .02 => t;
                // advance time
                1 => n.gain;
                0.1 :: second => now;
            }
        } else if (whatPlaying == "vessel1") 
        {
            1 => n.gain;
            for (0 => int i; i < 3; i++)
            {
                // sweep the filter resonant frequency
                500.0 + Std.fabs(Math.sin(t)) * 200.0 => f.freq;
                t + .02 => t;
                // advance time
                0.1 :: second => now;
            }
        } else if (whatPlaying == "bequiet"){
             0 => n.gain;
        }
     
    }
}