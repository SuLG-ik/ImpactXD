using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Players
{
    public class PlayerPreviews : MonoBehaviour
    {
        private PlayerPreview[] fields;

        private PlayerPreview[] GetFields()
        {
            return fields ??= GetComponentsInChildren<PlayerPreview>();
        }

        public async UniTask<PlayerPreview> HandleField()
        {
            var clicks = GetFields().Where(field => field.GetPreset() != null)
                .Select(field => field.HandleField());
            return (await UniTask.WhenAny(clicks)).result;
        }
    }
}