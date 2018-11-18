/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50720
Source Host           : localhost:3306
Source Database       : buding

Target Server Type    : MYSQL
Target Server Version : 50720
File Encoding         : 65001

Date: 2018-11-18 18:54:45
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for baseuser
-- ----------------------------
DROP TABLE IF EXISTS `baseuser`;
CREATE TABLE `baseuser` (
  `ID` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'ID',
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '用户名',
  `Passwrod` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '密码',
  `DispName` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '昵称',
  `Sex` int(255) DEFAULT NULL COMMENT '性别',
  `Mail` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '邮箱',
  `Mobile` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '手机号码',
  `Avatar` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '头像',
  `IdentityCode` varchar(30) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '身份证号',
  `Address` varchar(200) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '地址',
  `LastLoginOn` datetime DEFAULT NULL COMMENT '最后登录时间',
  `LastLoginIP` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '最后登录IP',
  `CreateOn` datetime DEFAULT NULL COMMENT '创建日期',
  `CreateUserId` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '创建人ID',
  `CreateBy` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '创建人名称',
  `ModifiedOn` datetime DEFAULT NULL COMMENT '更新时间',
  `ModifiedUserId` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '更新人Id',
  `ModifiedBy` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '更新人名称',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------
-- Records of baseuser
-- ----------------------------
