Noise n => LPF f => dac;
0.0 => float t;

for (0 => int i; i < 3; i++)
{
    // sweep the filter resonant frequency
    350.0 + Std.fabs(Math.sin(t)) * 300.0 => f.freq;
    t + .02 => t;
    // advance time
    1 :: second => now;
}

for (0 => int i; i < 3; i++)
{
    // sweep the filter resonant frequency
    425.0 + Std.fabs(Math.sin(t)) * 200.0 => f.freq;
    t + .02 => t;
    // advance time
    1 :: second => now;
}

for (0 => int i; i < 3; i++)
{
    // sweep the filter resonant frequency
    500.0 + Std.fabs(Math.sin(t)) * 200.0 => f.freq;
    t + .02 => t;
    // advance time
    1 :: second => now;
}