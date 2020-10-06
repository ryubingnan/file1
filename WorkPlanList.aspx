<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkPlanList.aspx.cs" Inherits="admin_manage_WorkPlanList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>日程列表</title>
    <link rel="stylesheet" type="text/css" href="/ext-2.0/resources/css/ext-all.css" />
    <script type="text/javascript" src="/ext-2.0/adapter/ext/ext-base.js"></script>
    <script type="text/javascript" src="/ext-2.0/ext-all.js"></script>
    <style type="text/css">
    #gv1
    {
         height:330px; width:100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="gv1">
    
    </div>
    <script type="text/javascript">
        function GetName(userid) {
            return arrayObj[userid]; //QQ:1416 7596 61
        }

        Ext.onReady(function () {

            var sm = new Ext.grid.CheckboxSelectionModel(); //定义选择列
            //下面是页眉列
            var cm = new Ext.grid.ColumnModel([
                new Ext.grid.RowNumberer(),
                sm,
                { header: '编号', dataIndex: 'id' },
                { header: '标题', dataIndex: 'title', width: 300 },
                { header: '撰写人', dataIndex: 'userid', renderer: GetName },
                { header: '时间', dataIndex: 'ctime' }
            ]);
            cm.defaultSortable = true; //排序

            var ds = new Ext.data.Store({//返回并解析数据源
                baseParams: { w: 'WorkPlanList' },
                proxy: new Ext.data.HttpProxy({
                    url: '/Common/ajax/Ajax.aspx?' + Math.random(),
                    method: 'POST'
                }),
                reader: new Ext.data.JsonReader({
                    totalProperty: 'totalProperty',
                    root: 'root',
                    fields: ["id", "title", "ctime", "userid", "contents"]
                })
            });

            ds.load({//发送请求 返回数据源
                params: { start: 0, limit: 10 }, //要发送到服务器的参数
                callback: function (success) {
                    if (success) {

                    } else { alert("加载数据失败，无对应数据或者系统出现异常！"); }
                }
            });

            var grid = new Ext.grid.GridPanel({
                el: 'gv1', //绑定到<div id='gv1'>111</div>上面
                id: "grid",
                ds: ds,
                cm: cm,
                sm: sm,
                title: '日程列表',
                loadMask: true,
                //超过长度带自动滚动条
                autoScroll: true,
                border: false,
                viewConfig: {
                    columnsText: "显示/隐藏列",
                    sortAscText: "正序排列",
                    sortDescText: "倒序排列",
                    forceFit: true
                },
                bbar: new Ext.PagingToolbar({
                    pageSize: 10,
                    store: ds,
                    displayInfo: true,
                    displayMsg: '显示第 {0} 条到 {1} 条记录，一共 {2} 条',
                    emptyMsg: "没有记录",
                    prevText: "上一页",
                    nextText: "下一页",
                    refreshText: "刷新",
                    lastText: "最后页",
                    firstText: "第一页",
                    beforePageText: "当前页",
                    afterPageText: "共{0}页"
                }),
                loadMask: {
                    msg: '正在加载数据，请稍侯……'
                },
                tbar: new Ext.Toolbar({
                    items:
                [
                {
                    id: 'btn1',
                    text: "添加",
                    handler: add
                },
                {
                    id: 'btn2',
                    text: "修改",
                    handler: edit
                },
                {
                    id: 'btn3',
                    text: "删除",
                    handler: function () {

                        var rec = grid.getSelectionModel().getSelected();
                        if (!rec) {
                            Ext.Msg.alert('提示', '请选择一行数据!');
                            return;
                        }
                        Ext.MessageBox.confirm('提示', '确定要删除吗？', function (btn) {

                            if (btn == 'yes') {

                                Ext.Ajax.request({
                                    url: '/Common/ajax/Ajax.aspx?' + Math.random(),
                                    method: 'post',
                                    params: { id: rec.get('id'), w: 'WorkPlanDelete' },
                                    success: function (res) {
                                        if (res.responseText == "1") {
                                            ds.reload(1);
                                        }
                                    },
                                    failure: function (res) {
                                        Ext.Msg.alert('提示', '服务访问不成功。');
                                    }
                                });
                            }

                        })

                    }
                }
                ]

                })

            });
            grid.render();

            //定义form
            Ext.QuickTips.init(); //开启表单提示
            var EditInfofp = new Ext.form.FormPanel({
                width: 600,
                height: 210,
                plain: true,
                layout: "form",
                defaultType: "textfield",
                labelWidth: 30,
                baseCls: "x-plain",
                //锚点布局-
                defaults: { anchor: "95%", msgTarget: "side" },
                buttonAlign: "center",
                bodyStyle: "padding:0 0 0 0",
                items:
                    [
                        {
                            xtype: "textfield",
                            layout: "column",
                            fieldLabel: "标题",
                            isFormField: true,
                            allowBlank: false,
                            blankText: "不能为空，请填写标题",
                            name: "title",
                            width: 300
                        },
                        {
                            xtype: "datefield",
                            layout: "column",
                            fieldLabel: "日期",
                            width: 200,
                            isFormField: true,
                            allowBlank: false,
                            blankText: "不能为空，请选择日期",
                            name: "ctime",
                            allowBlank: false,
                            altFormats: 'Y-m-d H:i:s',
                            format: 'Y-m-d H:i:s',
                            emptyText: 'Select a date...'
                        },
                        {
                            xtype: "htmleditor",
                            fieldLabel: "内容",
                            name: "contents",
                            width: 480,
                            height: 260
                        }
                    ]
            });

            //定义窗口
            EditInfo = function (row) {

                var EditInfoWin = new Ext.Window({
                    title: "修改:" + row.get("title") + row.get("ctime"),
                    width: 600,
                    height: 400,
                    plain: true,
                    resizable: false,
                    closeAction: 'hide',
                    collapsible: true, //允许缩放条
                    //draggable: false,
                    modal: 'true',
                    buttonAlign: "right",
                    border: false,  //因为要在Window中嵌套一个FormPanel子面板，所以禁用Window本身的border效果会比较美观
                    layout: "column",   //这个属性配合内部嵌套的FormPanel的frame:true正合适
                    bodyStyle: "padding:5px 0px 0 5px",
                    items: [EditInfofp],
                    listeners: {
                        "show": function () {
                            //当window show
                            EditInfofp.getForm().loadRecord(row);
                        }
                    },
                    buttons:
                    [
                        {
                            text: "保存",
                            minWidth: 70,
                            handler: function () {
                                if (EditInfofp.getForm().isValid()) {
                                    //弹出效果
                                    Ext.MessageBox.show
                                (
                                    {
                                        msg: '正在保存，请稍等...',
                                        progressText: 'Saving...',
                                        width: 300,
                                        wait: true,
                                        waitConfig: { interval: 200 },
                                        icon: 'download',
                                        animEl: 'saving'
                                    }
                                );
                                    setTimeout(function () {
                                        Ext.MessageBox.hide();
                                    }, 1000);
                                    EditInfofp.form.submit({
                                        url: '/Common/ajax/Ajax.aspx?' + Math.random(),
                                        method: 'post',
                                        params: { w: 'WorkPlanEdit', id: row.get("id") },
                                        success: function (form, action) {
                                            //成功后
                                            var flag = action.result.success;
                                            if (flag == "true") {
                                                EditInfoWin.hide();
                                                ds.reload();
                                            }
                                        },
                                        failure: function (form, action) {
                                            Ext.MessageBox.alert("提示!", "保存信息失败!");
                                        }
                                    });
                                }
                            }
                        },
                        {
                            text: "重置",
                            minWidth: 70,
                            handler: function () {
                                EditInfofp.getForm().loadRecord(row);
                            }

                        },
                        {
                            text: "取消",
                            minWidth: 70,
                            handler: function () {
                                EditInfoWin.hide();
                            }
                        }
                    ]
                });
                EditInfoWin.show();
            }

            //win.show();
            function edit() {
                var row = Ext.getCmp("grid").getSelectionModel().getSelections();
                if (row.length == 0) {
                    Ext.Msg.alert("提示信息", "您没有选中任何行!");
                }
                else if (row.length > 1) {
                    Ext.Msg.alert("提示信息", "对不起只能选择一个!");
                } else if (row.length == 1) {
                    EditInfo(row[0]);
                }
            }

            function add() {
                var AddInfoWin = new Ext.Window({
                    title: "添加日程",
                    width: 600,
                    height: 400,
                    plain: true,
                    resizable: false,
                    closeAction: 'hide',
                    collapsible: true, //允许缩放条
                    //draggable: false,
                    modal: 'true',
                    buttonAlign: "right",
                    border: false,  //因为要在Window中嵌套一个FormPanel子面板，所以禁用Window本身的border效果会比较美观
                    layout: "column",   //这个属性配合内部嵌套的FormPanel的frame:true正合适
                    bodyStyle: "padding:5px 0px 0 5px",
                    items: [EditInfofp],
                    buttons:
                    [
                        {
                            text: "保存",
                            minWidth: 70,
                            handler: function () {
                                if (EditInfofp.getForm().isValid()) {
                                    //弹出效果
                                    Ext.MessageBox.show
                                (
                                    {
                                        msg: '正在保存，请稍等...',
                                        progressText: 'Saving...',
                                        width: 300,
                                        wait: true,
                                        waitConfig: { interval: 200 },
                                        icon: 'download',
                                        animEl: 'saving'
                                    }
                                );
                                    setTimeout(function () {
                                        Ext.MessageBox.hide();
                                    }, 1000);
                                    EditInfofp.form.submit({
                                        url: '/Common/ajax/Ajax.aspx?' + Math.random(),
                                        method: 'post',
                                        params: { w: 'WorkPlanAdd' },
                                        success: function (form, action) {
                                            //成功后
                                            var flag = action.result.success;
                                            if (flag == "true") {
                                                AddInfoWin.hide();
                                                ds.reload();
                                            }
                                        },
                                        failure: function (form, action) {
                                            Ext.MessageBox.alert("提示!", "保存信息失败!");
                                        }
                                    });
                                }
                            }
                        },
                        {
                            text: "重置",
                            minWidth: 70,
                            handler: function () {
                               
                            }

                        },
                        {
                            text: "取消",
                            minWidth: 70,
                            handler: function () {
                                AddInfoWin.hide();
                            }
                        }
                    ]
                });
                AddInfoWin.show();
            
            }


        })
    </script>
    </form>
</body>
</html>
