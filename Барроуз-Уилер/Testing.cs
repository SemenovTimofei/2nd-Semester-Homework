public class Testing
{
    private static bool TestBWTransform()
    {
        if (BWT.BWTransform("banana") != ("nnbaaa", 3))
        {
            return false;
        }
        if (BWT.BWTransform("a") != ("a", 0))
        {
            return false;
        }
        if (BWT.BWTransform("aaaa") != ("aaaa", 0))
        {
            return false;
        }
        if (BWT.BWTransform("SIX.MIXED.PIXIES.SIFT.SIXTY.PIXIE.DUST.BOXES") != ("TEXYDST.E.IXIXIXXSSMPPS.B..E.S.EUSFXDIIOIIIT", 29))
        {
            return false;
        }

        return true;
    }

    private static bool TestInverseBWT()
    {
        if (BWT.InverseBWT("TEXYDST.E.IXIXIXXSSMPPS.B..E.S.EUSFXDIIOIIIT", 29) != "SIX.MIXED.PIXIES.SIFT.SIXTY.PIXIE.DUST.BOXES")
        {
            return false;
        }

        return true;
    }

    public static bool TestAll()
    {
        return TestBWTransform() && TestInverseBWT();
    }
}