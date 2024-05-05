namespace MiraboSync.View
{
    public static class SchemaExtension
    {

        // Convert from Unity Vector3 to Colyseus Vector3
        public static Colyseus.Vector3 ToColyseusVector3(this UnityEngine.Vector3 vector3)
        {
            return new Colyseus.Vector3()
            {
                x = vector3.x,
                y = vector3.y,
                z = vector3.z
            };
        }

        // Convert from Colyseus Vector3 to Unity Vector3
        public static UnityEngine.Vector3 ToUnityVector3(this Colyseus.Vector3 vector3)
        {
            return new UnityEngine.Vector3(vector3.x, vector3.y, vector3.z);
        }

        // Convert from Colyseus Color to Unity Color
        public static UnityEngine.Color ToUnityColor(this Colyseus.RGBA color)
        {
            return new UnityEngine.Color(color.R, color.G, color.B, color.A);
        }

        // Convert from Unity Color to Colyseus Color
        public static Colyseus.RGBA ToColyseusColor(this UnityEngine.Color color)
        {
            return new Colyseus.RGBA()
            {
                R = color.r,
                G = color.g,
                B = color.b,
                A = color.a
            };
        }
    }
}
