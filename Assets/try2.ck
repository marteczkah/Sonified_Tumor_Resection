// create our OSC receiver
OscRecv orec;
// port 6449
7001 => orec.port;
// start listening (launch thread)
orec.listen();
orec.event("/message/address") @=> OscEvent rate_event; 
while ( true )
{ 
    rate_event => now; // wait for events to arrive.
    
    // grab the next message from the queue. 
    while( rate_event.nextMsg() != 0 )
    { 
        // getFloat fetches the expected float
        // as indicated in the type string ",f"
        <<< rate_event.getFloat() >>>;
    }
}       