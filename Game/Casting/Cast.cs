using System;

namespace Snake_Game.Game.Casting
{
    /// <summary>
    /// A cast contains a dictionary of Actor lists, each keyed to a groupname.
    /// </summary>
    public class Cast
{
    private Dictionary<String, List<IActor>> actors = new Dictionary<String, List<IActor>>();
    /// <summary>
    /// Adds the given Actor to the given group.
    /// </summary>
    /// <param name="group"></param>
    /// <param name="actor"></param>
    public void Add(string group, IActor actor)
    {
        if (!actors.ContainsKey(group))
        {
            actors[group] = new List<IActor>();
        }
        if (!actors[group].Contains(actor))
        {
            actors[group].Add(actor);
        }
    }
    /// <summary>
    /// Removes the given actor from the given group.
    /// </summary>
    /// <param name="group"></param>
    /// <param name="actor"></param>
    public void Remove(string group, IActor actor)
    {
        if (actors.ContainsKey(group))
        {
            actors[group].Remove(actor);
        }
    }
    /// <summary>
    /// Returns a list of all Actors
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    public List<IActor> GetActors()
    {
        List<IActor> results = new List<IActor>();
        foreach (List<IActor> result in actors.Values)
        {
            results.AddRange(result);
        }
        return results;
    }
    /// <summary>
    /// Returns a list of all actors belonging to  a given group
    /// </summary>
    /// <returns></returns>
    public List<IActor> GetActors(string group)
    {
        List<IActor> results = new List<IActor>();
        if (actors.ContainsKey(group))
        {
            results.AddRange(actors[group]);
        }
        return results;
    }
    public IActor GetFirstActor(string group)
    {
        if (actors.ContainsKey(group) & actors.Count > 0)
        {
            return actors[group][0];
        }
        else
        {
            return null;
        }
    }
    public void Update(int maxX, int maxY)
    {
        foreach (IActor a in GetActors())
        {
            a.Update(maxX, maxY);
        }
    }
    public void Draw()
    {
        foreach (IActor a in GetActors())
        {
            a.Draw();
        }
    }
}
}
