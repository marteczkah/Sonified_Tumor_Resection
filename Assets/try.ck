OscIn oin;
OscMsg msg;
7001 => oin.port;

while (true) 
{
    while (oin.recv(msg))
    {
        SinOsc m => SinOsc c => dac;
        550 => c.freq;
        500 => m.freq;
        300 => m.gain;
        2 => c.sync;
        0.5 :: second => now;
    }
}
