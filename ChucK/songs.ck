SndBuf buf;

me.sourceDir() + "/Songs_Wav/do_i_wanna_know.wav" => string music_file;
music_file => buf.read; 

buf => dac;
220 => buf.freq;

20::second => now;
