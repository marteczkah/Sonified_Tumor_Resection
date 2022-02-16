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