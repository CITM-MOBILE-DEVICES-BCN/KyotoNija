using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NavigationSystem;

public class NavigationTest
{
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        Navigation navigation = new Navigation();
        
        navigation.LoadScene("Lobby");
        yield return new WaitForSeconds(1);
        navigation.LoadScene("RobotinMeta");
        yield return new WaitForSeconds(1);
        navigation.LoadScene("RobotinGame");
        yield return new WaitForSeconds(1);

        yield return null;
    }
}
