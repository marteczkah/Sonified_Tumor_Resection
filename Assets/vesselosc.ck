OscIn oin;
if( me.args() ) me.arg(0) => Std.atoi => oin.port;
else 8001 => oin.port;

oin.listenAll();

OscMsg msg;

while (true) 
{
    oin => now;
    while (oin.recv(msg))
    {
        Noise n => LPF f => dac;
        0.0 => float t;
        msg.getString(0) => string whatPlaying;
        if (whatPlaying == "vessel3") 
        {
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
            for (0 => int i; i < 3; i++)
            {
                // sweep the filter resonant frequency
                425.0 + Std.fabs(Math.sin(t)) * 200.0 => f.freq;
                t + .02 => t;
                // advance time
                0.1 :: second => now;
            }
        } else if (whatPlaying == "vessel3") 
        {
            for (0 => int i; i < 3; i++)
            {
                // sweep the filter resonant frequency
                500.0 + Std.fabs(Math.sin(t)) * 200.0 => f.freq;
                t + .02 => t;
                // advance time
                0.1 :: second => now;
            }
        }
    }
}