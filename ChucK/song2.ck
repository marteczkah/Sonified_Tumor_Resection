SndBuf mySound => Pan2 pan => dac;
// get file path and load file all in one line!
me.dir()+"/Songs_Wav/do_i_wanna_know.wav" => mySound.read;
// play our sound over and again in an infinite loop
while (true)
{
    // random gain, rate (pitch), and pan each time
    Math.random2f(0.1,1.0) => mySound.gain;
    Math.random2f(-1.0,1.0) => pan.pan;
    Math.random2f(0.2,1.8) => mySound.rate;
    // (re)start the sound by setting position to 0
    0 => mySound.pos;
    // advance time so we can hear it
    500.0 :: ms => now;
}