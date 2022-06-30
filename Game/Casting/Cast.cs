using System;

namespace Snake_Game.Game.Casting
{
    /// <summary>
    /// A cast contains a dictionary of Actor lists, each keyed to a groupname.
    /// </summary>
    public class Cast
{
    private Dictionary<String, List<Actor>> actors = new Dictionary<String, List<Actor>>();
    /// <summary>
    /// Adds the given Actor to the given group.
    /// </summary>
    /// <param name="group"></param>
    /// <param name="actor"></param>
    public void Add(string group, Actor actor)
    {
        if (!actors.ContainsKey(group))
        {
            actors[group] = new List<Actor>();
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
    public void Remove(string group, Actor actor)
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
    public List<Actor> GetActors()
    {
        List<Actor> results = new List<Actor>();
        foreach (List<Actor> result in actors.Values)
        {
            results.AddRange(result);
        }
        return results;
    }
    /// <summary>
    /// Returns a list of all actors belonging to  a given group
    /// </summary>
    /// <returns></returns>
    public List<Actor> GetActors(string group)
    {
        List<Actor> results = new List<Actor>();
        if (actors.ContainsKey(group))
        {
            results.AddRange(actors[group]);
        }
        return results;
    }
    public Actor GetFirstActor(string group)
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
        foreach (Actor a in GetActors())
        {
            a.Update(maxX, maxY);
        }
    }
    public void Draw()
    {
        foreach (Actor a in GetActors())
        {
            a.Draw();
        }
    }
}
}
