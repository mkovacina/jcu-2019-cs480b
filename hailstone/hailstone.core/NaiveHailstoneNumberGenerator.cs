using System;
using System.Collections.Generic;

namespace hailstone.core
{
    public sealed class NaiveHailstoneNumberGenerator : HailstoneNumberGenerator
    {
		// one place to initialize a readonly
	    private readonly Guid guid = Guid.NewGuid();

	    public NaiveHailstoneNumberGenerator()
	    {
			// the other place to initialize a readonly
		    guid = Guid.NewGuid();
	    }

	    public long ComputeHailstoneNumber(long input)
	    {
		    return 0;
	    }

        public IEnumerable<long> GenerateSequence(long input)
        {
            throw new System.NotImplementedException();
        }

        public Guid ID
        {
	        get
	        {
		        return guid;

	        }
        }
    }
}