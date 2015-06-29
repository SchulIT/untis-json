using System;

namespace UntisJson.Model
{
    [Flags]
    public enum Type
    {
        Entfall = 1,
        Betreuung = 2,
        Sondereinsatz = 4,
        Wegverlegung = 8,
        Freisetzung = 16,
        PlusAlsVertreter = 32,
        Teilvertretung = 64,
        Hinverlegung = 128,
        Raumvertretung = 65536,
        Pausenaufsichtsvertretung = 131072,
        StundeIstUnterrichtsfrei = 262144,
        KennzeichenNichtDrucken = 524288,
        KennzeichenNeu = 1048576
    }
}
