// noise generator, biquad filter, dac (audio output) 
Noise n => BiQuad f => dac;
// set biquad pole radius
//.99 => f.prad;
// set biquad gain
//100 => f.freq;
// set equal zeros 
//1 => f.eqzs;
// our float
0.0 => float t;

// infinite time-loop
while( true )
{
    // sweep the filter resonant frequency
    100.0 + Std.fabs(Math.sin(t)) * 100.0 => f.freq;
    t + .01 => t;
    // advance time
    5::ms => now;
}