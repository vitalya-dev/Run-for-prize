using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGeneration {
    public class LevelUtils {
        public static int get_level_build_index(string level_name) {
            return SceneUtility.GetBuildIndexByScenePath(level_name);
        }
    }
}