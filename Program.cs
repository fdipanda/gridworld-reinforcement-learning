using System;
using System.Collections.Generic;

public class gw
{
    public int r = 3;
    public int c = 4;
    public st[,] g;
    public double n;
    public double rc;

    public gw(double x, double rw)
    {
        n = x / 100.0;
        rc = rw;
        g = new st[r, c];
        ini();
    }

    void ini()
    {
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                g[i, j] = new st(i, j);
                g[i, j].re = rc;
            }
        }

        g[0, 3].te = true;
        g[0, 3].re = 1;
        g[1, 3].te = true;
        g[1, 3].re = -1;
        g[1, 1].wa = true;
        g[1, 1].re = 0;
    }

    public st gs(int rr, int cc)
    {
        if (rr < 0 || rr >= r || cc < 0 || cc >= c)
            return null;
        return g[rr, cc];
    }

    public void p()
    {
        Console.WriteLine("Grid:");
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                var b = g[i, j];
                if (b.wa)
                    Console.Write(" W ");
                else if (b.te)
                    Console.Write($" {b.re:+0;-0} ");
                else
                    Console.Write($" {b.re:0.0} ");
            }
            Console.WriteLine();
        }
    }
}

public class st
{
    public int r;
    public int c;
    public bool te;
    public bool wa;
    public double re;
    public double v;
    public pd po;

    public st(int rr, int cc)
    {
        r = rr;
        c = cc;
        te = false;
        wa = false;
        re = 0;
        v = 0;
        po = pd.n;
    }
}

public enum pd
{
    n = ' ',
    u = '↑',
    d = '↓',
    l = '←',
    r = '→'
}

public class vi
{
    gw w;
    double g;
    double sc;
    double o;

    (int dr, int dc, pd d)[] m = {
        (-1, 0, pd.u),
        (1, 0, pd.d),
        (0, -1, pd.l),
        (0, 1, pd.r)
    };

    public vi(gw ww, double gg)
    {
        w = ww;
        g = gg;
        sc = ww.rc;
        o = 1 - ww.n;
    }

    public void run()
    {
        for (int t = 0; t < 100; t++)
        {
            double[,] nv = new double[w.r, w.c];

            for (int i = 0; i < w.r; i++)
            {
                for (int j = 0; j < w.c; j++)
                {
                    var b = w.g[i, j];
                    if (b.wa || b.te)
                    {
                        nv[i, j] = b.re;
                        continue;
                    }

                    double bv = -9999;
                    pd bd = pd.n;

                    foreach (var x in m)
                    {
                        double cv = calc(b, x.dr, x.dc);
                        if (cv > bv)
                        {
                            bv = cv;
                            bd = x.d;
                        }
                    }

                    nv[i, j] = bv;
                    b.po = bd;
                }
            }

            for (int i = 0; i < w.r; i++)
                for (int j = 0; j < w.c; j++)
                    w.g[i, j].v = nv[i, j];
        }

        pp();
    }

    double calc(st b, int dr, int dc)
    {
        var mn = nx(b, dr, dc);
        var l = nx(b, -dc, dr);
        var r = nx(b, dc, -dr);

        double t = 0;
        t += w.n * (sc + g * mn.v);
        t += (o / 2) * (sc + g * l.v);
        t += (o / 2) * (sc + g * r.v);
        return t;
    }

    st nx(st b, int dr, int dc)
    {
        int nr = b.r + dr;
        int nc = b.c + dc;

        if (nr < 0 || nr >= w.r || nc < 0 || nc >= w.c || w.g[nr, nc].wa)
            return b;

        return w.g[nr, nc];
    }

    void pp()
    {
        Console.WriteLine("Result:");
        for (int i = 0; i < w.r; i++)
        {
            for (int j = 0; j < w.c; j++)
            {
                var b = w.g[i, j];
                if (b.wa)
                    Console.Write(" W ");
                else if (b.te)
                    Console.Write($"{b.re,3:+0;-0} ");
                else
                    Console.Write($"{b.v,3:0.0}{(char)b.po} ");
            }
            Console.WriteLine();
        }
    }
}

public class ql
{
    gw w;
    double a;
    double g;
    double e;
    bool de;
    Dictionary<(int, int), Dictionary<pd, double>> q;

    public ql(gw ww, double aa, double gg, double ee, bool dd)
    {
        w = ww;
        a = aa;
        g = gg;
        e = ee;
        de = dd;
        q = new Dictionary<(int, int), Dictionary<pd, double>>();

        for (int i = 0; i < w.r; i++)
        {
            for (int j = 0; j < w.c; j++)
            {
                var b = w.g[i, j];
                if (!b.wa && !b.te)
                {
                    q[(i, j)] = new Dictionary<pd, double>
                    {
                        {pd.u, 0},
                        {pd.d, 0},
                        {pd.l, 0},
                        {pd.r, 0}
                    };
                }
            }
        }
    }

    public void lrn(int k)
    {
        for (int t = 0; t < k; t++)
        {
            if (de)
                e *= 0.99;

            var s = rnd();

            while (!s.te)
            {
                pd act = pick(s);
                var ns = mv(s, act);
                double rw = ns.re;

                double bn = ns.te ? 0 : q[(ns.r, ns.c)].Values.Max();
                double cq = q[(s.r, s.c)][act];
                q[(s.r, s.c)][act] = cq + a * (rw + g * bn - cq);

                s = ns;
            }
        }
    }

    pd pick(st s)
    {
        if (new Random().NextDouble() < e)
            return (pd)new Random().Next(4);
        else
            return q[(s.r, s.c)].OrderBy(x => x.Value).Last().Key;
    }

    st mv(st s, pd d)
    {
        int nr = s.r, nc = s.c;
        switch (d)
        {
            case pd.u: nr--; break;
            case pd.d: nr++; break;
            case pd.l: nc--; break;
            case pd.r: nc++; break;
        }

        var nb = w.gs(nr, nc);
        return nb == null || nb.wa ? s : nb;
    }

    st rnd()
    {
        Random rand = new Random();
        st b = null;
        while (b == null || b.te || b.wa)
        {
            int rr = rand.Next(w.r);
            int cc = rand.Next(w.c);
            b = w.g[rr, cc];
        }
        return b;
    }

    public void show()
    {
        Console.WriteLine("Q:");
        foreach (var s in q)
        {
            Console.Write($"({s.Key.Item1},{s.Key.Item2}): ");
            foreach (var act in s.Value)
                Console.Write($"{act.Key}:{act.Value:F1} ");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Assignment 3");

        Console.Write("Noise (5-20): ");
        double n = double.Parse(Console.ReadLine());

        Console.Write("Cost: ");
        double c = double.Parse(Console.ReadLine());

        Console.Write("Discount: ");
        double d = double.Parse(Console.ReadLine());

        var g = new gw(n, c);
        g.p();

        Console.WriteLine("1. VI");
        Console.WriteLine("2. QL");
        string ch = Console.ReadLine();

        if (ch == "1")
        {
            var v = new vi(g, d);
            v.run();
        }
        else if (ch == "2")
        {
            Console.Write("Explore: ");
            double e = double.Parse(Console.ReadLine());

            Console.Write("Decay? (y/n): ");
            bool dec = Console.ReadLine() == "y";

            Console.Write("Episodes: ");
            int ep = int.Parse(Console.ReadLine());

            var q = new ql(g, 0.1, d, e, dec);
            q.lrn(ep);
            q.show();
        }
    }
}