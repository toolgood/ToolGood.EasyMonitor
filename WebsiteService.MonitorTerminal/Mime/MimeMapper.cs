﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebsiteService.MonitorTerminal.Mime
{
    /// <summary>
    /// 默认MIME映射器，可以根据文件扩展名获取标准内容类型。
    /// </summary>
    public class MimeMapper : IMimeMapper
    {
        /// <summary>
        /// 默认Mime  - 如果没有找到任何其他映射则作为默认的Mime-Type
        /// </summary>
        public const string DefaultMime = "application/octet-stream";

        ///// <summary>
        ///// 在文件路径中搜索文件扩展名的默认正则表达式
        ///// </summary>
        //private readonly Regex _pathExtensionPattern = new Regex("\\.(\\w*)$");

        /// <summary>
        /// Mime类型的默认字典(Content types)
        /// </summary>
        public static Dictionary<string, string> MimeTypes { get; }

        static MimeMapper()
        {
            MimeTypes = DefaultMimeItems.Items.ToDictionary(item => "." + item.Extension, item => item.MimeType);
        }
        /// <summary>
        /// 
        /// </summary>
        public MimeMapper() : this(null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="extensions"></param>
        public MimeMapper(params MimeMappingItem[] extensions)
        {
            Extend(extensions);
        }

        /// <summary>
        /// 扩展mime映射规则的标准列表。扩展的具有更高的优先级 - 如果扩展具有与标准项相同的扩展名，则会覆盖默认的mime
        /// </summary>
        /// <param name="extensions"></param>
        /// <returns></returns>
        public IMimeMapper Extend(params MimeMappingItem[] extensions)
        {
            if (extensions != null) {
                foreach (var mapping in extensions) {
                    if (MimeTypes.ContainsKey(mapping.Extension)) {
                        MimeTypes[mapping.Extension] = mapping.MimeType;
                    } else {
                        MimeTypes.Add(mapping.Extension, mapping.MimeType);
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// 返回特定文件扩展名的Content-Type，如果未找到任何对应关系，则返回默认值
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public string GetMimeFromExtension(string fileExtension)
        {
            fileExtension = (fileExtension ?? string.Empty).ToLower();
            if (MimeTypes.ContainsKey(fileExtension)) { return MimeTypes[fileExtension]; }
            return DefaultMime;
        }

        /// <summary>
        /// 根据路径获取MimeType
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetMimeFromPath(string path)
        {
            var extension = System.IO.Path.GetExtension(path);
            return GetMimeFromExtension(extension);
        }

    }
}