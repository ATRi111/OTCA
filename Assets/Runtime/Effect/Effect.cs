using MyTool;
using System.Text;

//各种行动对Entity产生影响的基本单位
public abstract class Effect
{
    public const int MaxProbability = 100;

    public static readonly RandomGroup randomGroup;
    static Effect()
    {
        randomGroup = RandomTool.GetGroup(ERandomGrounp.Battle);
    }
    public static int NextInt()
        => randomGroup.RandomInt(1, MaxProbability + 1);

    public int probability;
    public int randomValue;
    public bool AlwaysHappen => probability == MaxProbability;
    public bool NeverHappen => probability == 0;
    public bool WillHappen
    {
        get
        {
            if (AlwaysHappen)
                return true;
            if (NeverHappen)
                return false;
            if (randomValue == -1)
                randomValue = NextInt();
            return randomValue <= probability;
        }
    }

    public Entity victim;
    public Effect(Entity victim, int probability = MaxProbability)
    {
        this.victim = victim;
        this.probability = probability;
        randomValue = -1;
    }
    public abstract void Apply();

    public virtual EntityAnimation GetAnimation() { return null; }


    /// <param name="result">描述时是否包含结果信息</param>
    public virtual void Describe(StringBuilder sb, bool result)
    {
        if (!result && !AlwaysHappen)
        {
            sb.Append(probability);
            sb.Append("%");
        }
        sb.Append("使");
        sb.Append(victim.RichTextName);
    }
}
