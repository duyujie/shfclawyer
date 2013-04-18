update main_class set class_name='诉讼知识' where id=19
update main_class set class_name='律师博文与手记' where id=59
update main_class set class_name='实用法规' where id=47

update article set big_class_id=59 where big_class_id=7
update article set module_class_id=59 where module_class_id=7

select a.*,b.class_name from site_class a,main_class b
where a.class_id=b.id and a.site_id=2

delete from site_class where class_id in(36,41,43,45,46,61,56,57,7,49)

update article set module_class_id=59 where big_class_id=59 and module_class_id in(21,36,49)